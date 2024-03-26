<template>
  
    <div justify="center">
      <v-dialog v-model="dialog" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="text-h5">Criar Categoria</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Nome da categoria*"
                    required
                  
                    v-model="categoria.descricao"
                  ></v-text-field>
                </v-col>
                
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="adicionarCategoria">
              Salvar
            </v-btn>
            <v-btn color="blue" text @click="dialog = false">
              Cancelar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-btn @click="dialog=true" color="primary" :rounded="true">
        <v-icon>mdi-format-list-group-plus</v-icon>
        cadastrar Categoria
      </v-btn>
    </div>
   
  
</template>


<script lang="ts">
import CategoriaModel from "@/Model/Itens/CategoriaModel";
import { Vue, Component } from "vue-property-decorator";
import { ItensActionTypes } from '@/store/Item/actions';
import { StoreNamespaces } from '@/store';
import { namespace } from 'vuex-class';

const item = namespace(StoreNamespaces.ITEM);
@Component({})
export default class CadastroCategoria extends Vue {

    @item.Action(ItensActionTypes.SALVAR_CATEGORIA_ITEM)
  public salvarCategoriaItem!:(categoria : CategoriaModel) => Promise<any>;

  public dialog = false;
 
  public categoria = new CategoriaModel();

  public async adicionarCategoria(){

    await this.salvarCategoriaItem(this.categoria).then(()=>{
    });
    this.dialog = false;
  }

}
</script>