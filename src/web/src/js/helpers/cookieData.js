import cookie from '../globalMethod/cookie.js';

export var userCookie = {
    key: "user",
    set(value) {
        cookie.set(this.key, value);
    },
    get() {
        return cookie.get(this.key);
    },
    remove() {
        cookie.remove(this.key);
    }
};