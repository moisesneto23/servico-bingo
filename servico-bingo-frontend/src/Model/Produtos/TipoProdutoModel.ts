import CategoriaProdutoModel from '@/Model/Produtos/CategoriaProdutoModel';
export default class TipoProdutoModel {
    id!: number;
    descricao!: string;
    categoriaProdutoId!: number;
    categoriaProduto!: CategoriaProdutoModel;
}