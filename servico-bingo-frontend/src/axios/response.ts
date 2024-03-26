import {AxiosResponse} from 'axios';

export default (response: AxiosResponse): AxiosResponse<any> | Promise<AxiosResponse<any>> => response;
