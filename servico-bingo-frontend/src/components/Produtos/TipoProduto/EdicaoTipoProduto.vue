<template>
  
    <div justify="center">
      <v-dialog v-model="dialog" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="text-h5">Editar Tipo Produto</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Nome do tipo produto*"
                    required
                    v-model="exibeTipoProduto.descricao"
                  ></v-text-field>
                </v-col>
                
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="processarEdicao(exibeTipoProduto)">
              Salvar Edição
            </v-btn>
            
            <v-btn color="blue" text @click="dialog = false">
              Cancelar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
       <v-btn text @click="dialog=true">
              <v-icon>mdi-circle-edit-outline</v-icon> 
              </v-btn>
    </div>
   
  
</template>


<script lang="ts">
import { Vue, Component,Prop } from "vue-property-decorator";

import { StoreNamespaces } from "@/store";
import { namespace } from "vuex-class";
import { ItensActionTypes } from "@/store/Item/actions";
import TipoProdutoModel from "@/Model/Produtos/TipoProdutoModel";
import { ProdutosActionTypes } from "@/store/Produtos/actions";

const produto = namespace(StoreNamespaces.PRODUTO);

@Component({})
export default class EdicaoTipoProduto extends Vue {
  public dialog = false;
 @produto.Action(ProdutosActionTypes.EDITAR_TIPO_PRODUTO)
  public editaTipoProduto!:(tipo: TipoProdutoModel) => Promise<any>;
  @Prop()
  public tipoProduto!: TipoProdutoModel;
  public get exibeTipoProduto(){
    return this.tipoProduto;
  }
  
  public processarEdicao(tipo: TipoProdutoModel){
    this.editarTipoProduto(tipo);
  }

  private async editarTipoProduto(tipo: TipoProdutoModel): Promise<any>{
       await this.editaTipoProduto(tipo).then(()=>{
        this.dialog = false;
        });
  }
}
</script>