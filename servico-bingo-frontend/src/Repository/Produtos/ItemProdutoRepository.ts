
import  { AppHttpAxios }  from '@/axios/AppHttpAxios';
import { Inject } from 'typescript-ioc';
import store from '@/store';
import ItemProdutoModel from '@/Model/Produtos/ItemProdutoModel';
export class ItemProdutoRepository {
    
   
    @Inject
    private $http!: AppHttpAxios;
    private idEmpresa = this.pegaIdEmpresa();
    private pegaIdEmpresa(): number{
        let id = localStorage.getItem('businessId') || '0';
        return parseInt(id);
    }
   
    public async obterTodosItensProduto(): Promise<ItemProdutoModel[]> {
        const result = await this.$http.get(`ItemProduto/${this.idEmpresa}`);
        return result.data;
    }

    public async obterItensCadastradoPorProduto(idProduto: number): Promise<ItemProdutoModel[]> {
        const result = await this.$http.get(`ItemProduto/produto/${idProduto}`);
        return result.data;
    }

    public async salvarItemProduto(Item: ItemProdutoModel): Promise<any> {
        const result = await this.$http.post('ItemProduto', Item);
    }

    public async editarItemProduto(Item: ItemProdutoModel): Promise<ItemProdutoModel> {
        const result = await this.$http.patch('ItemProduto', Item);
        return result.data;
    }
    public async delete(id: any) : Promise<any>{
        const url =`ItemProduto/${id}`;
        await this.$http.delete(url);
    }
}