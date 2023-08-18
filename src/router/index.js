import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Begin'
  },
  {
    path: '/login',
    name: 'Signin',
    component: () => import('../views/Signin.vue')
  },
  {
    path: `/Cart/:id`,
    name: "Cart-Customer",
    component: () => import('@/views/Cart.vue'),
    props:true //router => router.params
  },
]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
