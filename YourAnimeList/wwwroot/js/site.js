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

async function init() {
    const node = document.querySelector("#type-text")

    await sleep(1000)
    node.text = ""

    while (true) {
        await node.type('Welcome, To Your Anime List!')
        await sleep(2000)
        await node.delete('Welcome, To Your Anime List!')
        await node.type('Enjoy Your Stay.')
        await sleep(2000)
        await node.delete('Enjoy Your Stay.')
    }
}


const sleep = time => new Promise(resolve => setTimeout(resolve, time))

class TypeAsync extends HTMLSpanElement {
    get text() {
        return this.innerText
    }
    set text(value) {
        return this.innerHTML = value
    }

    get typeInterval() {
        const randomMs = 100 * Math.random()
        return randomMs < 50 ? 10 : randomMs
    }

    async type(text) {
        for (let character of text) {
            this.text += character
            await sleep(this.typeInterval)
        }
    }

    async delete(text) {
        for (let character of text) {
            this.text = this.text.slice(0, this.text.length - 1)
            await sleep(this.typeInterval)
        }
    }
}

customElements.define('type-async', TypeAsync, { extends: 'span' })


init()

function addDarkmodeWidget() { new Darkmode().showWidget(); } window.addEventListener('load', addDarkmodeWidget);

const darkmode = new Darkmode(options);
darkmode.showWidget();