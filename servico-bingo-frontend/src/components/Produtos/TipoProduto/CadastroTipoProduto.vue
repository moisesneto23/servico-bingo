<template>
  
    <div justify="center">
      <v-dialog v-model="dialogTipo" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="text-h5">Criar Tipo Produto</span>
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-text-field
                    label="Nome do Tipo*"
                    required
                    item-value="descricao"
                    v-model="tipo.descricao"
                  ></v-text-field>
                </v-col>

                <v-col cols="12" sm="6">
                  <v-select
                   v-model="select"
   
    :items="descricaoCategorias"
    :item-title="descricaoCategorias"
    item-value="id"
    label="selecione"
    persistent-hint
    return-object
    single-line
                  ></v-select>
                </v-col>
               
              </v-row>
            </v-container>
            <small>*indica campo obrigatorio</small>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn dark  @click="selecuinaIdSelect(), adicionarTipo()">
              Salvar
            </v-btn>
            <v-btn color="blue" text @click="dialogTipo = false">
              Cancelar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
      <v-btn @click="dialogTipo=true" color="primary"  :rounded="true">
        <v-icon>mdi-view-grid-plus-outline</v-icon>
        cadastrar Tipo produto
      </v-btn>
    </div>
   
  
</template>


<script lang="ts">
import { Vue, Component } from "vue-property-decorator";

import TipoService from "@/Service/Itens/TipoService";
import { Inject } from "typescript-ioc";
import { StoreNamespaces } from "@/store";
import { namespace } from "vuex-class";
import TipoProdutoModel from "@/Model/Produtos/TipoProdutoModel";
import CategoriaProdutoModel from "@/Model/Produtos/CategoriaProdutoModel";
import { ProdutosActionTypes } from "@/store/Produtos/actions";

const produto = namespace(StoreNamespaces.PRODUTO);
@Component({})
export default class CadastroTipoProduto extends Vue {
    @Inject
  public _tipoService!: TipoService;
  public tipo= new TipoProdutoModel();
  public dialogTipo = false;
public select = '';
private idSelect?: number;
public selecuinaIdSelect(){
  this.idSelect = this.categoriasProduto.find(x=>x.descricao == this.select)?.id;
}

@produto.State
 private categoriasProduto!: CategoriaProdutoModel[];
  
    @produto.Action(ProdutosActionTypes.OBTER_CATEGORIAS_PRODUTO)
  public obterTodasCategorias!:() => Promise<any>;

   @produto.Action(ProdutosActionTypes.SALVAR_TIPO_PRODUTO)
  public salvarTipoItem!:(tipo: TipoProdutoModel) => Promise<any>;
  
  public get descricaoCategorias(){
    return this.categoriasProduto.map((c)=>c.descricao);
  }
  public async  mounted(){
   await this.obterTodasCategorias();
  }



  public adicionarTipo(){
   
    this.tipo.categoriaProdutoId = this.idSelect || 0;
    this.salvarTipoItem(this.tipo).then(()=>{
       this.dialogTipo = false;
    });
  }
}
</script>