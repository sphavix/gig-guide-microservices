import axios, { AxiosResponse } from 'axios';
import { Gig } from '../models/gig';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}

axios.defaults.baseURL = 'http://localhost:5001/api';

axios.interceptors.response.use(async response => {
   try{
    await sleep(1000);
    return response;
   }
    catch(error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
}

const Gigs = {
    list: () => requests.get<Gig[]>('/gigs/getallgigs'),
    details: (id: string) => requests.get<Gig>(`/gigs/GetGigById/${id}`),
    create: (gig: Gig) => axios.post<void>('/gigs/CreateGig', gig),
    update: (gig: Gig) => axios.put<void>(`/gigs/UpdateGig`, gig),
    delete: (id: string) => axios.delete<void>(`/gigs/DeleteGig/${id}`)
}

const agent = {
    Gigs
}

export default agent;