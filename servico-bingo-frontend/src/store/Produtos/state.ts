import ItemProdutoModel from '@/Model/Produtos/ItemProdutoModel';
import TipoProdutoModel from '@/Model/Produtos/TipoProdutoModel';
import CategoriaProdutoModel from '@/Model/Produtos/CategoriaProdutoModel';
import ProdutoModel from '@/Model/Produtos/ProdutoModel';


export class ProdutoState {
  public itensProduto?: ItemProdutoModel[];
  public tiposProduto?: TipoProdutoModel[] ;
  public categoriasProduto?: CategoriaProdutoModel[] ;
  public produtos?: ProdutoModel[];
}

export const state: ProdutoState = {
  itensProduto: [],
  tiposProduto: [],
  categoriasProduto: [],
  produtos: [],
};
