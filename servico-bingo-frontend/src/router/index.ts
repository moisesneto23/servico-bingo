import Vue from "vue";
import beforeEnter from "./beforeEnter";
import beforeEach from './beaforeEach';
import VueRouter, { RouteConfig } from "vue-router";
import CadastroEmpresa from "@/views/visitante/CadastroEmpresa.vue";
import MinhasCartelas from "@/views/visitante/MinhasCartelas.vue";
import Login from "@/views/visitante/Login.vue";

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  //ptodas que nãao for visitante tem que ter um componente especifico de navegação
  {
    path: "/Home",
    name: "Visitante",
    component: () => import("@/views/navegacaoRotas/NavegacaoVisitante.vue"),
    children: [
      {
        path: "/login",
        name: "Login",
        component: Login,
      },
      {
        path: "/cadastro-empresa",
        name: "CadastroEmpresa",
        component: CadastroEmpresa,
      },
      {
        path: "/cartelas",
        name: "cartelas",
        component: MinhasCartelas,
      },
    ],
  },

  {
    path: "/",
    name: "Inicio",
    component: () => import("@/views/navegacaoRotas/NavegacaoInicio.vue"),
    children: 
    [
      {
        path: "/cadastro/itens",
        name: "CadastroItens",
        component: () => import("@/views/Inicio/CadastroItens.vue"),
      },
      {
        path: "/cadastro/produtos",
        name: "CadastroProdutos",
        component: () => import('@/views/Inicio/CadastroProdutos.vue'),
      },
      {
        path: "/cadastro/orcamento",
        name: "CadastroProdutos",
        component: () => import('@/views/Inicio/CadastroOrcamento.vue'),
      },
    ],
    beforeEnter,
  },
];
const router = new VueRouter({
  mode: "history",
  routes,
});
router.beforeEach(beforeEach);
export default router;
