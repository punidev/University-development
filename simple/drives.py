import sys
import win32com.client as wc

class Drive():
    disks = []
    colItems = wc.Dispatch("WbemScripting.SWbemLocator")\
                 .ConnectServer(".", "root/CIMV2")\
                 .ExecQuery("SELECT * FROM Win32_LogicalDisk")

    def writeObj(self, object):
        return object == None and "None" or str(object)

    def getDisks(self):
        for o in self.colItems:
            self.disks.append(o.Name)
        return self.disks

    def getCurrentInfo(self,inp):
        for o in self.colItems:
            if o.Name == inp:

                print(  "Access: " + (self.writeObj(o.Access) == 0 and "\033[31mDenied\033[0m" or "\033[32mGranted\033[0m") +\
                        "\033[0m\nCaption: \033[34m" + self.writeObj(o.Caption) +\
                        "\033[0m\nCompressed: \033[34m" + self.writeObj(o.Compressed) +\
                        "\033[0m\nCreationClassName: \033[34m" + self.writeObj(o.CreationClassName) +\
                        "\033[0m\nDescription: \033[34m" + self.writeObj(o.Description) +\
                        "\033[0m\nDeviceID: \033[34m" + self.writeObj(o.DeviceID) +\
                        "\033[0m\nDriveType: \033[34m" + self.writeObj(o.DriveType) +\
                        "\033[0m\nFileSystem: \033[34m" + self.writeObj(o.FileSystem) +\
                        "\033[0m\nFreeSpace: \033[34m" + self.writeObj(o.FreeSpace) + " bytes" +\
                        "\033[0m\nName: \033[34m" + self.writeObj(o.Name) +\
                        "\033[0m\nSize: \033[34m" + self.writeObj(o.Size) + " bytes" +\
                        "\033[0m\nSystemName: \033[34m" + self.writeObj(o.SystemName) +\
                        "\033[0m\nVolumeSerialNumber: \033[34m" + self.writeObj(o.VolumeSerialNumber)+
                        "\033[0m"
                        )
if __name__ == '__main__':
    n = Drive()
    print(n.getDisks())
    n.getCurrentInfo(input("Set HDD Name: ") + ":")


