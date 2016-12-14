# -*- coding: utf_8 -*-
import socket

open_ports = []
ports = [21, 22, 23, 25, 38, 43, 80, 109, 110, 115, 118, 119, 143,
        194, 220, 443, 540, 585, 591, 1112, 1433, 1443, 3128, 3197,
        3306, 4000, 4333, 5100, 5432, 6669, 8000, 8080, 9014, 9200]
def check_port(host, port):
        sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        sock.settimeout(0.01)
        try:
            sock.connect((host, port))  # Конектимся
        except:
            pass
        else:
            open_ports.append(port)
        sock.close()



host = '192.168.1.102'

try:
    socket.inet_aton(host)

    for i in ports:
        check_port(host, i)
    print("Opened ports %s" % open_ports)
except socket.error:
    print('Неверный ip адрес.')
finally:
    host = '192.168.1.102'
