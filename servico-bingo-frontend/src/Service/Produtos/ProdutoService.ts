
import ProdutoModel from '@/Model/Produtos/ProdutoModel';
import { ProdutoRepository } from '@/Repository/Produtos/ProdutoRepository';
import { Inject } from 'typescript-ioc';

export default class ProdutoService {
    
    @Inject
    private _produto!: ProdutoRepository;

    public async obterTodosProdutos(): Promise<ProdutoModel[]> {
        return await this._produto.obterTodosProdutos();
    }

    public async salvarProduto(Produto:ProdutoModel): Promise<any> {
         await this._produto.salvarProduto(Produto);
    }

    public async editarProduto(Produto:ProdutoModel): Promise<ProdutoModel> {
       return await this._produto.editarProduto(Produto);
    }
    public async delete(id: number): Promise<any>{
        await this._produto.delete(id);
    }
};