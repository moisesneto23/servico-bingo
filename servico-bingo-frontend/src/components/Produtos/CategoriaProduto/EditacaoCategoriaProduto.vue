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
                    v-model="exibeCategoriaProduto.descricao"
                  ></v-text-field>
                </v-col>
                
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="processarEdicao(exibeCategoriaProduto)">
              Salvar
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
import { namespace } from "vuex-class";
import { StoreNamespaces } from "@/store";
import CategoriaProdutoModel from "@/Model/Produtos/CategoriaProdutoModel";
import { ProdutosActionTypes } from "@/store/Produtos/actions";

const produto = namespace(StoreNamespaces.PRODUTO);
@Component({})
export default class EdicaoCategoriaProduto extends Vue {

  @produto.Action(ProdutosActionTypes.EDITAR_CATEGORIA_PRODUTO)
  public editarCategoriaProduto!:(categoriaProduto: CategoriaProdutoModel) => Promise<any>;
  public dialog = false;

  @Prop()
  private categoriaProduto!: CategoriaProdutoModel;
  public get exibeCategoriaProduto(){
    return this.categoriaProduto;
  }
  mounted(){
    console.log(this.categoriaProduto)
  }
  public processarEdicao(categoriaProduto: CategoriaProdutoModel){
    this.editarCategoriaProduto(categoriaProduto).then(()=>{
      this.dialog = false; 
      this.$emit('categoriaAlterada',this.categoriaProduto);
    });
  }

}
</script>