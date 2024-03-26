<template>
  
    <div justify="center">
      <v-dialog v-model="dialogproduto" persistent max-width="800px">
        <v-card>
          <v-card-title>
            <span class="text-h5">Criar produto Unitario</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>

                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Nome do produto*"
                     v-model="produto.nome"
                    required
                  ></v-text-field>
                </v-col>
               
                <v-col cols="12" sm="6">
                  <v-select
                    :items="descricaoTipos"
                    label="Selecione o tipo do produto*"
                    required
                    v-model="select"
                  ></v-select>
                </v-col>
              
                
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="selecuinaIdSelect(), salvarproduto()">
              Salvar
            </v-btn>
            <v-btn color="blue" text @click="dialogproduto = false">
              Cancelar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-btn @click="dialogproduto=true"  color="primary" :rounded="true">
        <v-icon>mdi-shape-square-plus</v-icon>
        Criar Produto
      </v-btn>
    </div>
   
  
</template>


<script lang="ts">
import ProdutoModel from "@/Model/Produtos/ProdutoModel";
import { StoreNamespaces } from "@/store";
import { Vue, Component } from "vue-property-decorator";
import { namespace } from "vuex-class";
import { ProdutosActionTypes } from "@/store/Produtos/actions";
import TipoProdutoModel from "@/Model/Produtos/TipoProdutoModel";
const produto = namespace(StoreNamespaces.PRODUTO);

@Component({})
export default class CadastroProduto extends Vue {
  @produto.Action(ProdutosActionTypes.SALVAR_PRODUTO)
  public salvaproduto!:(produto: ProdutoModel) => Promise<any>;

  @produto.State
  private tiposProduto!: TipoProdutoModel[];

  public produto = new ProdutoModel();
  public selecuinaIdSelect(){
  this.idSelect = this.tiposProduto.find(x=>x.descricao == this.select)?.id;
  }
  public idSelect?: number;
  public select = '';
  public async salvarproduto(){
    this.produto.tipoProdutoId = this.idSelect || 0;
    await this.salvaproduto(this.produto).then(()=>{
        this.descricaoTipos;
      this.dialogproduto = false;
    })
  }

  public get descricaoTipos(){
    return this.tiposProduto.map(c=>c.descricao);
  }
  public dialogproduto = false;
}
</script>