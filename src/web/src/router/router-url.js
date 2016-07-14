export default {
  "/": {
    component: function (resolve) {
      require(['./view/index/index.vue'], resolve)
    }
  },
  "/role/:id":{
      component: function (resolve) {
        require(['./view/role/maintain.vue'], resolve)
      }
  },
  "/user/:id":{
      component: function (resolve) {
        require(['./view/user/maintain.vue'], resolve)
      }
  },
  "/scenic/maintain/:id":{
      component: function (resolve) {
        require(['./view/scenic/maintain.vue'], resolve)
      }
  },
  "/scenic/import/:id":{
      component: function (resolve) {
        require(['./view/scenic/import.vue'], resolve)
      }
  },
  //页面状态码配置
  "401": {
    component: function (resolve) {
      require(['./state/401.vue'], resolve);
    }
  },
  "404": {
    component: function (resolve) {
      require(['./state/404.vue'], resolve);
    }
  }
}