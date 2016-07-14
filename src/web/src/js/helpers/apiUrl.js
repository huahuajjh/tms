export const user = {
    login: {    //登录地址
        type: "POST",
        url: "/user/login"
    },
    info: {
        type: "POST",
        url: "/user/info"
    },
    editPassword: {
        type: "POST",
        url: "/user/password"
    },
    exists: {
        type: "POST",
        url: "/user/exists"
    },
    add: {
        type: "POST",
        url: "/user/add"
    },
    list: {
        type: "POST",
        url: "/user/list",
        dataType: "json"
    },
    edit: {
        type: "POST",
        url: "/user/edit",
    },
    stateAll: {
        type: "POST",
        url: "/user/stateAll",
        dataType: "json"
    },
    setState: {
        type: "POST",
        url: "/user/state"
    },
    del: {
        type: "POST",
        url: "/user/del"
    },
    resetPassword: {
        type: "POST",
        url: "/user/initPassword"
    }
}

export const menu = {
    all: {
        url: "/menu/all",
        type: "POST",
        dataType: "json"
    }
}

export const role = {
    all: {
        url: "/role/all",
        type: "POST",
        dataType: "json"
    },
    allInfo: {
        url: "/role/allInfo",
        type: "POST",
        dataType: "json"
    },
    add: {
        url: "/role/add",
        type: "POST"
    },
    list: {
        url: "/role/list",
        type: "POST",
        dataType: "json"
    },
    info: {
        url: "/role/info",
        type: "POST",
        dataType: "json"
    },
    del: {
        url: "/role/del",
        type: "POST"
    },
    edit: {
        url: "/role/edit",
        type: "POST"
    }
}

export const scenery = {
    add: {
        url: "/scenery/add",
        type: "POST"
    },
    list: {
        url: "/scenery/list",
        type: "POST",
        dataType: "json"
    },
    edit: {
        url: "/scenery/edit",
        type: "POST"
    },
    del: {
        url: "/scenery/del",
        type: "POST"
    }
}