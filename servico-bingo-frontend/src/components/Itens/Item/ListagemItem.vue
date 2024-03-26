<template>
  <div id="cadastroOrcamento">
    <v-tabs v-model="tab" grow icons-and-text background-color="#9FA8" color="#4A148C">
      <v-tabs-slider></v-tabs-slider>

      <v-tab href="#tab-1">
        Unidade
        <v-icon>mdi-checkbox-blank-circle</v-icon>
      </v-tab>

      <v-tab href="#tab-2">
        Comprimento
        <v-icon>mdi-arrow-right-thin</v-icon>
      </v-tab>

      <v-tab href="#tab-3">
        Perimetro
        <v-icon>mdi-network-strength-outline</v-icon>
      </v-tab>

      <v-tab href="#tab-4">
        Area
        <v-icon>mdi-square-outline</v-icon>
      </v-tab>

    <v-tab href="#tab-5">
        Volume
        <v-icon>mdi-package-variant-closed</v-icon>
      </v-tab>
    </v-tabs>

    <v-tabs-items v-model="tab" data-app style="background-color: #f2f2f2;">

      <v-tab-item value="tab-1">
        <div>
          <v-card-text>
            <lista-unidade></lista-unidade>
          </v-card-text>
          <cadastro-item-unitario></cadastro-item-unitario>
        </div>
      </v-tab-item>

      <v-tab-item value="tab-2">
        <div>
          <v-card-text>
            <lista-linear></lista-linear>
          </v-card-text>
          <cadastro-item-linear></cadastro-item-linear>
        </div>
      </v-tab-item>

       <v-tab-item value="tab-3">
        <div>
          <v-card-text>
            <lista-perimetro></lista-perimetro>
          </v-card-text>
          <cadastro-item-perimetro></cadastro-item-perimetro>
        </div>
      </v-tab-item>

      <v-tab-item value="tab-4">
        <div>
          <v-card-text>
            <lista-area></lista-area>
          </v-card-text>
          <cadastro-item-area></cadastro-item-area>
        </div>
      </v-tab-item>

      <v-tab-item value="tab-5">
        <div>
          <v-card-text>
            <lista-volume></lista-volume>
          </v-card-text>
          <cadastro-item-volume></cadastro-item-volume>
        </div>
      </v-tab-item>
    </v-tabs-items>


  </div>
</template>
<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import CadastroItemUnitario from '@/components/Itens/Item/dimencionalidades/CadastroItemUnitario.vue' ;
import ListaUnidade from '@/components/Itens/Item/dimencionalidades/ListaUnidade.vue' ;
import CadastroItemLinear from '@/components/Itens/Item/dimencionalidades/CadastroItemLinear.vue' ;
import ListaLinear from '@/components/Itens/Item/dimencionalidades/ListaLinear.vue' ;
import CadastroItemArea from '@/components/Itens/Item/dimencionalidades/CadastroItemArea.vue' ;
import ListaArea from '@/components/Itens/Item/dimencionalidades/ListaArea.vue' ;
import CadastroItemVolume from '@/components/Itens/Item/dimencionalidades/CadastroItemVolume.vue' ;
import ListaVolume from '@/components/Itens/Item/dimencionalidades/ListaVolume.vue' ;
import CadastroItemPerimetro from '@/components/Itens/Item/dimencionalidades/CadastroItemPerimetro.vue' ;
import ListaPerimetro from '@/components/Itens/Item/dimencionalidades/ListaPerimetro.vue' ;

@Component({
  components: {
    CadastroItemUnitario,
    ListaUnidade,
    CadastroItemLinear,
    ListaLinear,
    CadastroItemArea,
    ListaArea,
    CadastroItemVolume,
    ListaVolume,
    CadastroItemPerimetro,
    ListaPerimetro,
  },
})
export default class ListagemItem extends Vue {
  public tab = null;
}
 


</script>
<style scoped>
#cadastroOrcamento{
  background-color: rgb(186, 186, 186);
}
</style>