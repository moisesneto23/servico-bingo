<template>
  
    <div justify="center">
      <v-dialog v-model="dialog" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="text-h5">Editar Produto</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Nome do produto*"
                    required
                    v-model="exibeProduto.nome"
                  ></v-text-field>
                </v-col>
                
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="processarEdicao(exibeProduto)">
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
import { ProdutosActionTypes } from "@/store/Produtos/actions";
import ProdutoModel from "@/Model/Produtos/ProdutoModel";

const produto = namespace(StoreNamespaces.PRODUTO);

@Component({})
export default class EdicaoTipoProduto extends Vue {
  public dialog = false;
 @produto.Action(ProdutosActionTypes.EDITAR_PRODUTO)
  public editaProduto!:(produto: ProdutoModel) => Promise<any>;
  @Prop()
  public produto!: ProdutoModel;
  public get exibeProduto(){
    return this.produto;
  }
  
  public processarEdicao(produto: ProdutoModel){
    this.editarProduto(produto);
  }

  private async editarProduto(produto: ProdutoModel): Promise<any>{
       await this.editaProduto(produto).then(()=>{
        this.dialog = false;
        });
  }
}
</script>