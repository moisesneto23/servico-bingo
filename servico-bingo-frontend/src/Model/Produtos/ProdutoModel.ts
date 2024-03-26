import TipoProdutoModel from "./TipoProdutoModel";

export default class ProdutoModel {
  public id!: number;
  public nome!: string;
  public valorVenda!: number;
  public valorCusto!: number;
  public tipoProdutoId!: number;
  public tipoItem!: TipoProdutoModel;
}