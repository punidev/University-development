# -*- coding: utf-8 -*-

import serial, enaml, io, sys, time

from atom.api import Atom, Unicode, Range, Bool, observe
from enaml.qt.qt_application import QtApplication


class COMport(Atom):

    send_data =\
    receive_data =\
    portS =\
    portR =\
    logTrace = Unicode()

    numIter = Range(low=1)
    it =\
    timeout_s =\
    timeout_r = Range(low=0)
    bauds = Range(low=9600)


    GetSendData =\
    _iter =\
    GetRecData = property()


    @GetSendData.getter
    def GetSendData(self):
        return str(self.send_data)

    @GetSendData.setter
    def GetSendData(self, value):
        self.send_data = value

    @GetRecData.getter
    def GetRecData(self):
        return str(self.receive_data)

    @GetRecData.setter
    def GetRecData(self, value):
        self.receive_data = value

    @_iter.getter
    def _iter(self):
        return self.numIter

    @_iter.setter
    def _iter(self, value):
        self.numIter = value


    def status(self):
        self.logTrace += "Port (" + self.portS + ") :: " + str(serial.Serial(self.portS).is_open and "opened" or "closed") + "<br>" +\
                         "Port (" + self.portR + ") :: " + str(serial.Serial(self.portR).is_open and "opened" or "closed") + "<br>"

    def SerialPorts(self):
        if sys.platform.startswith('win'):
            ports = ['COM%s' % (i + 1) for i in range(256)]
        else:
            raise EnvironmentError('Unsupported platform')

        result = []
        for port in ports:
            try:
                s = serial.Serial(port)
                s.close()
                result.append(port)
            except (OSError, serial.SerialException):
                pass
        return result

    def TraceReceive(self):
        i = 0
        try:
            p1 = serial.Serial(str(self.portS))
            p1.writeTimeout = 0
            p1.baudrate = self.bauds
            p1.timeout = self.timeout_s
            p2 = serial.Serial(str(self.portR))
            p2.baudrate = self.bauds
            p2.timeout = self.timeout_r

            for i in range(self._iter):
                p1.write(self.GetSendData)
                self.GetRecData = p2.read(len(self.GetSendData))
                if str(self.log()) != 'None':
                    self.logTrace += str(self.log())+"<br>"
                self.it = i
        except UnicodeEncodeError('Кириллица не поддерживается'):
            pass
        finally:
            p1.close()
            p2.close()


    def log(self):
        if self.GetRecData != '':
            templ = "Port ({port}): Recieved >> \"{receive_data}\" ({size} bytes), number: {r} of {allr}"
            s = templ.format(
                port=self.portR,
                receive_data=self.GetRecData,
                r=self.it,
                size=sys.getsizeof(self.GetRecData),
                allr=self._iter
            )
            return s
class COMsettings(Atom):

    GetSPort = property()

    logTrace =\
    dsrdtr =\
    rtscts =\
    xonxoff =\
    bits =\
    parity =\
    portS =\
    bytesize = Unicode()

    Bytes = ['5', '6', '7', '8']
    Bits = ['1', '1.5', '2']
    Paritys = ['EVEN','MARK','ODD','NONE','SPACE']

    Rtscts =\
    Dsrdtr =\
    Xonxoff = ['Disable', 'Enable']

    bauds = Range(low=9600)
    wtimeout =\
    timeout = Range(low=0)

    @GetSPort.getter
    def GetSPort(self):
        return str(self.portS)

    @GetSPort.setter
    def GetSPort(self, value):
        self.portS = value

    def byteSelector(self, value):
        return {
            '5': serial.FIVEBITS,
            '6': serial.SIXBITS,
            '7': serial.SEVENBITS,
            '8': serial.EIGHTBITS
        }.get(value)

    def booleanSelector(self, value):
        return {
            'Disable': False,
            'Enable': True,
        }.get(value)

    def paritySelector(self, value):
        return {
            'EVEN': serial.PARITY_EVEN,
            'MARK': serial.PARITY_MARK,
            'NONE': serial.PARITY_NONE,
            'ODD': serial.PARITY_ODD,
            'SPACE': serial.PARITY_SPACE
        }.get(value)

    def clear(self):
        self.logTrace = ''

    def biteSelector(self, value):
        return {
            '1': serial.STOPBITS_ONE,
            '1.5': serial.STOPBITS_ONE_POINT_FIVE,
            '2': serial.STOPBITS_TWO,
        }.get(value)

    def Defaults(self):
        p = serial.Serial(self.GetSPort)
        self.logTrace += \
            "<font color=red style='font-family:Trebuchet ms'>Default of "\
            + self.GetSPort\
            + "</font><br><font style='font-family:courier new'>"\
            + str(p)\
            + " <br>"

    def InitialPort(self):
        p = serial.Serial(self.GetSPort)
        p.bytesize = self.byteSelector(self.bytesize)
        p.baudrate = self.bauds
        p.stopbits = self.biteSelector(self.bits)
        p.parity = self.paritySelector(self.parity)
        p.timeout = self.timeout
        p.writeTimeout = self.wtimeout
        p.xonxoff = self.booleanSelector(self.xonxoff)
        p.rtscts = self.booleanSelector(self.rtscts)
        p.dsrdtr = self.booleanSelector(self.dsrdtr)
        self.logTrace += \
            "<font color=green style='font-family:Trebuchet ms'>Saved settings of " \
            + self.GetSPort \
            + "</font><br><font style='font-family:courier new'>" \
            + str(p) \
            + " <br>"

    def SaveportSettings(self, path):
        o = open(path, 'w')
        try:
            o.write(
                        self.GetSPort + "," +
                        self.bytesize + "," +
                        str(self.bauds) + "," +
                        self.bits + "," +
                        self.parity + "," +
                        str(self.timeout) + "," +
                        str(self.wtimeout) + "," +
                        self.xonxoff + "," +
                        self.rtscts + "," +
                        self.dsrdtr
                    )
        except ValueError('Unicode error'):
            pass
        finally:
            o.close()

    def OpenportSettings(self, path):
        f = open(path, 'r')
        o = []
        try:
            o = f.read().split(',')
            p = serial.Serial(o[0])
            p.bytesize = self.byteSelector(o[1])
            p.baudrate = int(o[2])
            p.stopbits = self.biteSelector(o[3])
            p.parity = self.paritySelector(o[4])
            p.timeout = int(o[5])
            p.writeTimeout = int(o[6])
            p.xonxoff = self.booleanSelector(o[7])
            p.rtscts = self.booleanSelector(o[8])
            p.dsrdtr = self.booleanSelector(o[9])
            self.logTrace += \
                "<font color=blue style='font-family:Trebuchet ms'>Loaded settings of " \
                + o[0] \
                + "</font><br><font style='font-family:courier new'>" \
                + str(p) \
                + " <br>"
        except ValueError('Unicode error'):
            pass
        finally:
            f.close()
class COMfile(Atom):

    ports=\
    portr=Unicode()

    def fStream(self, ipath, opath):
        f = open(ipath, 'r')
        o = open(opath, 'w')
        p1 = serial.Serial(str(self.ports))
        p2 = serial.Serial(str(self.portr))
        p1.writeTimeout = 0
        message = f.read()
        p1.write(message)
        back = p2.read(len(message))
        f.close()
        o.write(back)
        o.close()
        p1.close()
        p2.close()

if __name__ == '__main__':
    with enaml.imports():
        from form import MainForm

    value = COMport()
    sp = COMsettings()
    filev = COMfile()
    app = QtApplication()

    view = MainForm(this=value, setport=sp, files=filev).show()

    app.start()
