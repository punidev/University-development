#!/usr/bin/env python
# -*- coding: utf-8 -*-

import os, sys, re, shutil, string, pwd, grp, stat
from optparse import OptionParser

if os.getuid() != 0:
    sys.exit("Скрипт должен работать с правами администратора!")

sname = os.path.basename(__file__)


def mainParse():
    parser = OptionParser(usage="usage: %prog [options] [add|drop] domain", version="%prog 1.0")
    parser.add_option(
        "-d", "--dir_site",
        default="/srv/www/",
        metavar="/srv/www/",
        help=u"Директория для домена."
    )
    parser.add_option(
        "-a", "--apache_bin",
        default="rcapache2",
        metavar="rcapache2",
        help=u"Файл apache2 для рестарта."
    )
    parser.add_option(
        "-c", "--apache_config_site",
        default="/etc/apache2/vhosts.d/",
        metavar="/etc/apache2/vhosts.d/",
        help=u"Директория виртуальных хостов от apache для настроек virtualhost."
    )
    parser.add_option(
        "-t", "--host",
        default="/etc/hosts",
        metavar="/etc/hosts",
        help=u"Системный файл hosts для внесения информации о домене."
    )
    parser.add_option(
        "-i", "--ip",
        default="127.0.0.1",
        metavar="127.0.0.1",
        help=u"IP для сайта."
    )
    parser.add_option(
        "-e", "--save",
        default="apachectl",
        metavar="apachectl",
        help=u"Сохранение доступа к хосту."
    )

    (options, args) = parser.parse_args()
    if len(args) != 2 or not args[0] in {"add": 0, "drop": 1}:
        parser.error(sname + " -h")
    return {"options": options, "args": args}


conf = mainParse()
options = conf['options']

stat_info = os.stat(options.dir_site)
options.uid = stat_info.st_uid
options.gid = stat_info.st_gid
options.user = pwd.getpwuid(options.uid)[0]
options.group = grp.getgrgid(options.gid)[0]


def remove_string(filename, string):
    rst = []
    with open(filename) as fd:
        t = fd.read()
        for line in t.splitlines():
            if line != string:
                rst.append(line)
    with open(filename, 'w') as fd:
        fd.write('\n'.join(rst))
        fd.write('\n')


def apache_site_config(name):
    file_name = options.apache_config_site + name + ".conf"
    dir_site = options.dir_site + name
    f = open(file_name, "w+")
    print >> f, '<VirtualHost *:80> \n' + \
    'DocumentRoot ' + dir_site + '\n' + \
    'ServerAlias www.' + name + '\n' + \
    'ServerName ' + name + '\n' + \
    'ScriptAlias /cgi-bin/ ' + dir_site + '/cgi-bin/\n\n' + \
    '<Directory "' + dir_site + '/">\n' + \
    '\tOptions Indexes FollowSymLinks\n' + \
    '\tAllowOverride None\n' + \
    '\t<IfModule !mod_access_compat.c>\n' + \
    '\t\tRequire all granted\n' + \
    '\t</IfModule>\n' + \
    '\t<IfModule mod_access_compat.c>\n' + \
    '\t\tOrder allow,deny\n' + \
    '\t\tAllow from all\n' + \
    '\t</IfModule>\n' + \
    '</Directory>\n\n' + \
    '<Directory "' + dir_site + '/cgi-bin/">\n' + \
    '\tAllowOverride None\n' + \
    '\tOptions +ExecCGI -Includes\n' + \
    '\t<IfModule !mod_access_compat.c>\n' + \
    '\t\tRequire all granted\n' + \
    '\t</IfModule>\n' + \
    '\t<IfModule mod_access_compat.c>\n' + \
    '\t\tOrder allow,deny\n' + \
    '\t\tAllow from all\n' + \
    '\t</IfModule>\n' + \
    '</Directory>\n\n' + \
    '<IfModule dir_module>\n' + \
    '\tDirectoryIndex index.php index.html index.cgi\n' + \
    '</IfModule>\n\n' + \
    '<IfModule mod_userdir.c>\n' + \
    '\tUserDir public_html\n' + \
    '\tInclude /etc/apache2/mod_userdir.conf\n' + \
    '</IfModule>\n' + \
    'ErrorLog "' + dir_site + '/log/error.log"\n' + \
    'CustomLog "' + dir_site + '/log/access.log" combined\n' + \
    'LogLevel warn\n\n' + \
    'HostnameLookups Off\n' + \
    'UseCanonicalName Off\n' + \
    'ServerSignature On\n' + \
    '</VirtualHost>'

    f.close()


def add_domain(name):
    dir_site = options.dir_site + name
    if os.path.exists(dir_site):
        sys.exit("Сайт " + name + " не может быть записан в " + dir_site)
    elif os.path.exists(options.apache_config_site + name):
        sys.exit(options.apache_config_site + name + " - Занят конфигурационный файл!")
    else:
        os.makedirs(dir_site + "/")
        os.makedirs(dir_site + "/cgi-bin/")
        os.makedirs(dir_site + "/log/")
        f = open(dir_site + "/index.html", "a+")
        f.write('Its work!')
        f.close()
        f = open(dir_site + "/cgi-bin/index.cgi", "a+")
        print >> f, '#!/usr/bin/env python'
        f.close()
        os.system("chown -R " + options.user + ":" + options.group + " " + dir_site)
        os.chmod(dir_site + "/cgi-bin/index.cgi", 755)
        apache_site_config(name)
        f = open(options.host, "a+")
        f.write("\n" + options.ip + "\t" + name + "\twww." + name)
        f.close()
        f = open(dir_site + "/.htaccess", "a+")
        f.write("AddDefaultCharset UTF-8")
        f.close()
        os.system(options.save + " -S")
        os.system(options.apache_bin + " restart")
        sys.exit("Домен http://" + name + " успешно создан")
    pass


def drop_domain(name):
    dir_site = options.dir_site + name;
    if os.path.exists(dir_site):
        shutil.rmtree(dir_site);
    if os.path.exists(options.apache_config_site + name):
        os.unlink(options.apache_config_site + name);
    remove_string(options.host, options.ip + "\t" + name + "\twww." + name);
    os.system(options.apache_bin + " restart");
    sys.exit("Упоминания о домене " + name + " удалены!");
    pass;


if conf["args"][0] in {"add": 0, "drop": 1}:
    if conf["args"][0] == "add":
        add_domain(conf["args"][1])
    else:
        drop_domain(conf["args"][1])
else:
    sys.exit("Команды " + conf["args"][0] + " не существует!")
