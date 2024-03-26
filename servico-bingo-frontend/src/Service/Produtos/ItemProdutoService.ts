
import ItemProdutoModel from '@/Model/Produtos/ItemProdutoModel';
import { ItemProdutoRepository } from '@/Repository/Produtos/ItemProdutoRepository';
import { Inject } from 'typescript-ioc';

export default class ItemProdutoService {
    
    @Inject
    private _itemRepository!: ItemProdutoRepository;

    public async obterTodosItensProduto(): Promise<ItemProdutoModel[]> {
        return await this._itemRepository.obterTodosItensProduto();
    }

    public async salvarItemProduto(Produto:ItemProdutoModel): Promise<any> {
         await this._itemRepository.salvarItemProduto(Produto);
    }

    public async editarItemProduto(Produto:ItemProdutoModel): Promise<ItemProdutoModel> {
       return await this._itemRepository.editarItemProduto(Produto);
    }
    public async delete(id: number): Promise<any>{
        await this._itemRepository.delete(id);
    }

    public async obterItensCadastradoPorProduto(idProduto: number): Promise<ItemProdutoModel[]> {
        return await this._itemRepository.obterItensCadastradoPorProduto(idProduto);
    }
};