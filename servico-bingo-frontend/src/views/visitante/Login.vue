<template>
  <div>
    <h1>login</h1>

    <v-container>
      <v-col>

          <v-text-field
            v-model="email"
            tipy="email"
            label="E-mail"
            required
          ></v-text-field>

         <v-text-field
            v-model="senha"
            :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
           
            :type="show1 ? 'text' : 'password'"
            name="input-10-1"
            label="Senha"
            hint="At least 8 characters"
            counter
            @click:append="show1 = !show1"
          ></v-text-field>

          <v-btn  color="secondary" style="background-color: blue"  large class="mr-4" @click="fazerLogin()"> Fazer Login </v-btn>
      </v-col>
    </v-container>
    <h3><v-btn text color="">Esqueci a Senha</v-btn></h3>
  </div>
</template>




<script lang='ts'>
import { Vue, Component } from "vue-property-decorator";
import Rotas from "@/router/Rotas";
import { StoreNamespaces } from '@/store';
import { Action } from 'vuex-class';
import { GlobalActionTypes } from '@/store/actions';
import Login from '@/Model/Login';
import router from "@/router";

@Component({
  components: {},
})
export default class Loginin extends Vue {

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
<style scoped>

</style>
