const option = {
    bottom: '64px',
    right: 'unset',
    left: '32px',
    time: '0.5s',
    //mixColor: '#fff',
    backgroundColor: '#whitesmoke',
    buttonColorDark: '#121212',
    buttonColorLight: '#whitesmoke',
    saveInCookies: false,
    label: '🌓',
    autoMatchOsTheme: true
}

function addDarkmodeWidget() { new Darkmode().showWidget(); } window.addEventListener('load', addDarkmodeWidget);

const darkmode = new Darkmode(options);
darkmode.showWidget();