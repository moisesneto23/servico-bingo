
import CategoriaProdutoModel from '@/Model/Produtos/CategoriaProdutoModel';
import { CategoriaProdutoRepository } from '@/Repository/Produtos/CategoriaProdutoRepository';
import { Inject } from 'typescript-ioc';

export default class CategoriaProdutoService {
    
    @Inject
    private _categoriaRepository!: CategoriaProdutoRepository;

    public async obterTodasCategoriasProduto(): Promise<CategoriaProdutoModel[]> {
        return await this._categoriaRepository.obterTodasCategoriasProduto();
    }

    public async salvarCategoriaProduto(Produto:CategoriaProdutoModel): Promise<any> {
         await this._categoriaRepository.salvarCategoriaProduto(Produto);
    }

    public async editarCategoriaProduto(Produto:CategoriaProdutoModel): Promise<CategoriaProdutoModel> {
       return await this._categoriaRepository.editarCategoriaProduto(Produto);
    }
    public async delete(id: number): Promise<any>{
        await this._categoriaRepository.delete(id);
    }
};