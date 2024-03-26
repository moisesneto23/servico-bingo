import ItemModel from "@/Model/Itens/ItemModel";
import { ItemRepository } from "@/Repository/Itens/ItemRepository";
import { Inject } from "typescript-ioc";

export default class ItemService {
    @Inject
    private _itemRepository!: ItemRepository;

    public async obterTodosItens(): Promise<ItemModel[]> {
        return await this._itemRepository.obterTodosItens();
    }

    public async salvarItem(item:ItemModel): Promise<any> {
         await this._itemRepository.salvarItem(item);
    }

    public async editarItem(item:ItemModel): Promise<void> {
        await this._itemRepository.editarItem(item);
    }
    public async delete(id: number): Promise<any>{
        await this._itemRepository.delete(id);
    }
}