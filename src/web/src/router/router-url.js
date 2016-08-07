export default {
  '/': {
    component: function (resolve) {
      require(['./view/index/index.vue'], resolve)
    }
  },
  '/role/:id': {
    component: function (resolve) {
      require(['./view/role/maintain.vue'], resolve)
    }
  },
  '/user/:id': {
    component: function (resolve) {
      require(['./view/user/maintain.vue'], resolve)
    }
  },
  '/scenic/maintain/:id': { // 维护景点
    component: function (resolve) {
      require(['./view/scenic/maintain.vue'], resolve)
    }
  },
  '/scenic/import/:id': { // 导入景点
    component: function (resolve) {
      require(['./view/scenic/import.vue'], resolve)
    }
  },
  '/ticket/maintain/:id': { // 维护门票
    component: function (resolve) {
      require(['./view/ticket/maintain.vue'], resolve)
    }
  },
  '/ticket/import/:id': { // 导入门票
    component: function (resolve) {
      require(['./view/ticket/import.vue'], resolve)
    }
  },
  '/ticket/export/:id': { // 导出门票
    component: function (resolve) {
      require(['./view/ticket/export.vue'], resolve)
    }
  },
  '/ticket/audit/:id': { // 审核门票
    component: function (resolve) {
      require(['./view/ticket/audit.vue'], resolve)
    }
  },
  '/ticket/extract/:id': { // 取出门票
    component: function (resolve) {
      require(['./view/ticket/extract.vue'], resolve)
    }
  },
  '/ticket/sms/:id': { // 维护门票短信
    component: function (resolve) {
      require(['./view/ticket/sms.vue'], resolve)
    }
  },
  '/ticket/tourist/:id': { // 查询游客信息
    component: function (resolve) {
      require(['./view/ticket/tourist.vue'], resolve)
    }
  },
  // 页面状态码配置
  '/401': {
    component: function (resolve) {
      require(['./state/401.vue'], resolve)
    }
  },
  '/404': {
    component: function (resolve) {
      require(['./state/404.vue'], resolve)
    }
  }
}
