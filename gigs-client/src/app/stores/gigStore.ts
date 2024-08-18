import { makeObservable } from "mobx";

export default class GigStore {
    title = 'Hello from Mobx';


    constructor(){
        makeObservable(this, {
            
        })
    }
}