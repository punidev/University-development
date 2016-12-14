import win32com.client as wc
class NetworkAdapter():

    indexs = []
    colItems = wc.Dispatch("WbemScripting.SWbemLocator")\
        .ConnectServer(".","root\cimv2")\
        .ExecQuery("SELECT * FROM Win32_NetworkAdapter")

    def WMIDateStringToDate(self,dtmDate):
        strDateTime = ""
        if (dtmDate[4] == 0):
            strDateTime = dtmDate[5] + '/'
        else:
            strDateTime = dtmDate[4] + dtmDate[5] + '/'
        if (dtmDate[6] == 0):
            strDateTime = strDateTime + dtmDate[7] + '/'
        else:
            strDateTime = strDateTime + dtmDate[6] + dtmDate[7] + '/'
            strDateTime = strDateTime + dtmDate[0] + dtmDate[1] + \
                          dtmDate[2] + dtmDate[3] + " " + dtmDate[8] + dtmDate[9]\
                          + ":" + dtmDate[10] + dtmDate[11] +':' + dtmDate[12] + dtmDate[13]
        return strDateTime

    def writeObj(self,object):
            return object == None and "None" or str(object)

    def getIndexs(self):
        for o in self.colItems:
            self.indexs.append({o.Index: o.Name})
        return self.indexs

    def printInd(self):
        for i in self.getIndexs():
            print(i)

    def indexParse(self, inp):
        for o in self.colItems:
            if o.Index==int(inp):
                print("AdapterType: \033[31m" + self.writeObj(o.AdapterType) + \
                      "\033[0m\nAdapterTypeId: \033[31m" + self.writeObj(o.AdapterTypeId) + \
                      "\033[0m\nAutoSense: \033[31m" + self.writeObj(o.AutoSense) + \
                      "\033[0m\nAvailability: \033[31m" + self.writeObj(o.Availability) + \
                      "\033[0m\nCaption: \033[31m" + self.writeObj(o.Caption) + \
                      "\033[0m\nConfigManagerErrorCode: \033[31m" + self.writeObj(o.ConfigManagerErrorCode) + \
                      "\033[0m\nConfigManagerUserConfig: \033[31m" + self.writeObj(o.ConfigManagerUserConfig) + \
                      "\033[0m\nCreationClassName: \033[31m" + self.writeObj(o.CreationClassName) + \
                      "\033[0m\nDescription: \033[31m" + self.writeObj(o.Description) + \
                      "\033[0m\nDeviceID: \033[31m" + self.writeObj(o.DeviceID) + \
                      "\033[0m\nErrorCleared: \033[31m" + self.writeObj(o.ErrorCleared) + \
                      "\033[0m\nErrorDescription: \033[31m" + self.writeObj(o.ErrorDescription) + \
                      "\033[0m\nIndex: \033[31m" + self.writeObj(o.Index) + \
                      "\033[0m\nInstallDate: \033[31m" + self.writeObj(o.InstallDate) + \
                      "\033[0m\nInstalled: \033[31m" + self.writeObj(o.Installed) + \
                      "\033[0m\nInterfaceIndex: \033[31m" + self.writeObj(o.InterfaceIndex) + \
                      "\033[0m\nLastErrorCode: \033[31m" + self.writeObj(o.LastErrorCode) + \
                      "\033[0m\nMACAddress: \033[31m" + self.writeObj(o.MACAddress) + \
                      "\033[0m\nManufacturer: \033[31m" + self.writeObj(o.Manufacturer) + \
                      "\033[0m\nMaxNumberControlled: \033[31m" + self.writeObj(o.MaxNumberControlled) + \
                      "\033[0m\nMaxSpeed: \033[31m" + self.writeObj(o.MaxSpeed) + \
                      "\033[0m\nName: \033[31m" + self.writeObj(o.Name) + \
                      "\033[0m\nNetConnectionID: \033[31m" + self.writeObj(o.NetConnectionID)

                      )

                print("\033[0m\nNetworkAddresses: \033[31m")
                strList = " "
                try:
                    for objElem in o.NetworkAddresses:
                        strList = strList + objElem + ","
                except:
                    strList = strList + 'null'
                print(strList)
                print("\033[0m\nPermanentAddress: \033[31m" + self.writeObj(o.PermanentAddress) + \
                      "\033[0m\nPNPDeviceID: \033[31m" + self.writeObj(o.PNPDeviceID))

                print("PowerManagementCapabilities: \033[31m")
                strList = " "
                try:
                    for objElem in o.PowerManagementCapabilities:
                        strList = strList + objElem + ","
                except:
                    strList = strList + 'null'
                print(strList)
                print("\033[0m\nPowerManagementSupported: \033[31m" + self.writeObj(o.PowerManagementSupported) + \
                      "\033[0m\nProductName: \033[31m" + self.writeObj(o.ProductName) + \
                      "\033[0m\nServiceName: \033[31m" + self.writeObj(o.ServiceName) + \
                      "\033[0m\nSpeed: \033[31m" + self.writeObj(o.Speed) + \
                      "\033[0m\nStatus: \033[31m" + self.writeObj(o.Status) + \
                      "\033[0m\nStatusInfo: \033[31m" + self.writeObj(o.StatusInfo) + \
                      "\033[0m\nSystemCreationClassName: \033[31m" + self.writeObj(o.SystemCreationClassName) + \
                      "\033[0m\nSystemName: \033[31m" + self.writeObj(o.SystemName) + \
                      "\033[0m\nTimeOfLastReset: \033[31m" + self.writeObj(self.WMIDateStringToDate(o.TimeOfLastReset))+"\033[0m")

    def printInfo(self, inputi):
        if inputi == '--help':
            self.printInd()
        else:
            self.indexParse(inputi)

if __name__ == '__main__':
    net = NetworkAdapter()
    while True:
        net.printInfo(input("Select Index, or --help to indexes list: "))