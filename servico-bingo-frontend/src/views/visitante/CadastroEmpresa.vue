<template>
  <div class="CadastroEmpresa">
    <etapas-cadastro-empresa></etapas-cadastro-empresa>
  </div>
</template>
<script lang='ts'>
import { Vue, Component } from "vue-property-decorator";
import Rotas from "@/router/Rotas";
import { StoreNamespaces } from '@/store';
import { Action } from 'vuex-class';
import { GlobalActionTypes } from '@/store/actions';
import EtapasCadastroEmpresa from '@/components/visitante/cadastroEmpresa/EtapasCadastroEmpresa.vue';


@Component({
  components: {
    EtapasCadastroEmpresa,
  },
})
export default class CadastroEmpresa extends Vue {

  private email = '';

  private senha = '';

  private group = null;
  private carregando =false;
  private show1= false;
  
@Action(GlobalActionTypes.FAZER_LOGIN)
private fazLogin!: (login:Login)=> Promise<void>;

public async fazerLogin(){

      this.carregando= true;
      const login = new Login(this.email, this.senha);
      await this.fazLogin(login).then(()=>{
        this.carregando =false;
        this.$router.push(Rotas.Inicio);
      });   
};
}
</script>
