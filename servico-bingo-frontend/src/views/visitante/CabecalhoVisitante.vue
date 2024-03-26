<template>
<nav>
     <span> <v-btn text> <router-link  :to="Login"> Login</router-link></v-btn> </span>
      <span> <v-btn text> <router-link :to="CadastroEmpresa"> cadastro</router-link> </v-btn> </span>
       <span> <v-btn text> <router-link :to="Sobre"> sobre</router-link> </v-btn> </span>

    </nav>
</template>
<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator';
import Rotas from '@/router/Rotas';
@Component({
  components: {

  }
})
export default class CabecalhoVisitante extends Vue{
 public Login = Rotas.Visitante.Login;
 public CadastroEmpresa = Rotas.Visitante.CadastroEmpresa;
 public Sobre = Rotas.Visitante.Sobre;
}
</script>

