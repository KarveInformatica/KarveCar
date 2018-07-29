import wpf

from System.Windows import Window

class MainWindow(Window):
    def __init__(self):
        wpf.LoadComponent(self, 'MainWindow.xaml')
