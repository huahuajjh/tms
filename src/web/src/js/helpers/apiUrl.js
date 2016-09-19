export const user = {
    login: {    //登录地址
        type: "POST",
        url: "http://localhost:1311/user/login"
    },
    info: {
        type: "POST",
        url: "http://localhost:1311/user/info"
    },
    editPassword: {
        type: "POST",
        url: "http://localhost:1311/user/password"
    },
    exists: {
        type: "POST",
        url: "http://localhost:1311/user/exists"
    },
    add: {
        type: "POST",
        url: "http://localhost:1311/user/add"
    },
    list: {
        type: "POST",
        url: "http://localhost:1311/user/list",
        dataType: "json"
    },
    edit: {
        type: "POST",
        url: "http://localhost:1311/user/edit",
    },
    stateAll: {
        type: "POST",
        url: "http://localhost:1311/user/stateAll",
        dataType: "json"
    },
    setState: {
        type: "POST",
        url: "http://localhost:1311/user/state"
    },
    del: {
        type: "POST",
        url: "http://localhost:1311/user/del"
    },
    resetPassword: {
        type: "POST",
        url: "http://localhost:1311/user/initPassword"
    }
}

export const menu = {
    all: {
        url: "http://localhost:1311/menu/all",
        type: "POST",
        dataType: "json"
    }
}

export const role = {
    all: {
        url: "http://localhost:1311/role/all",
        type: "POST",
        dataType: "json"
    },
    allInfo: {
        url: "http://localhost:1311/role/allInfo",
        type: "POST",
        dataType: "json"
    },
    add: {
        url: "http://localhost:1311/role/add",
        type: "POST"
    },
    list: {
        url: "http://localhost:1311/role/list",
        type: "POST",
        dataType: "json"
    },
    info: {
        url: "http://localhost:1311/role/info",
        type: "POST",
        dataType: "json"
    },
    del: {
        url: "http://localhost:1311/role/del",
        type: "POST"
    },
    edit: {
        url: "http://localhost:1311/role/edit",
        type: "POST"
    }
}

export const scenery = {
    add: {
        url: "http://localhost:1311/scenery/add",
        type: "POST"
    },
    list: {
        url: "http://localhost:1311/scenery/list",
        type: "POST",
        dataType: "json"
    },
    edit: {
        url: "http://localhost:1311/scenery/edit",
        type: "POST"
    },
    del: {
        url: "http://localhost:1311/scenery/del",
        type: "POST"
    }
}

export const ticket = {
    add: {
        url: "http://localhost:1311/ticket/add",
        type: "POST"
    },
    list: {
        url: "http://localhost:1311/ticket/list",
        type: "POST",
        dataType: "json"
    },
    del: {
        url: "http://localhost:1311/ticket/del",
        type: "POST"
    },
    edit: {
        url: "http://localhost:1311/ticket/edit",
        type: "POST"
    },
    audit: {
        url: "http://localhost:1311/ticket/audit",
        type: "POST"
    },
    untakenList: {
        url: "http://localhost:1311/ticket/untakenList",
        type: "POST",
        dataType: "json"
    },
    taken: {
        url: "http://localhost:1311/ticket/taken",
        type: "POST"
    },
    sendSMS: {
        url: "http://localhost:1311/ticket/sendSMS",
        type: "POST"
    }
}

export const excel = {
    scenery: {
        import: "http://localhost:1311/excelFile/importScenery.xls",
        export: "http://localhost:1311/excel/exportScenery",
        upload: "http://localhost:1311/excel/importScenery"
    },
    ticket: {
        import: "http://localhost:1311/excelFile/importTicket.xls",
        export: "http://localhost:1311/excel/exportTicket",
        upload: "http://localhost:1311/excel/importTicket"
    }
}