import win32com.client as wc, re

colItems = wc.Dispatch("WbemScripting.SWbemLocator")\
    .ConnectServer('.',"root\cimv2")\
    .ExecQuery("SELECT * FROM Win32_ClassicCOMClassSettings")

def RExpression(object):
    return re.findall(r'"{(.*?)}"', object, re.DOTALL)

def writeObj(object):
    return object == None and "None" or str(RExpression(object))

for o in colItems:
    print("Element: \033[31m" + writeObj(o.Element) + "\033[0m\nSetting: \033[31m" + writeObj(o.Setting) + "\033[0m")
    print()