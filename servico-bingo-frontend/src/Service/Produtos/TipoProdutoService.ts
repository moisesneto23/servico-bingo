
import TipoProdutoModel from '@/Model/Produtos/TipoProdutoModel';
import { TipoProdutoRepository } from '@/Repository/Produtos/TipoProdutoRepository';
import { Inject } from 'typescript-ioc';

export default class TipoProdutoService {
    
    @Inject
    private _tipoRepository!: TipoProdutoRepository;

    public async obterTodosTiposProduto(): Promise<TipoProdutoModel[]> {
        return await this._tipoRepository.obterTodosTiposProduto();
    }

    public async salvarTipoProduto(Produto:TipoProdutoModel): Promise<any> {
         await this._tipoRepository.salvarTipoProduto(Produto);
    }

    public async editarProduto(Produto:TipoProdutoModel): Promise<TipoProdutoModel> {
       return await this._tipoRepository.editarTipoProduto(Produto);
    }
    public async delete(id: number): Promise<any>{
        await this._tipoRepository.delete(id);
    }
};