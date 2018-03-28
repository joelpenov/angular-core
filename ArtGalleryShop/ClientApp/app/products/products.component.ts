
import { Component } from "@angular/core"

@Component({
    selector: 'products-list',
    templateUrl: './products.component.html'
})

export class Products {
    public products = [
        {
            title: "First Product",
            price: 98.97
        },
        {
            title: "Second Product",
            price: 14.97
        }, {
            title: "Third Product",
            price: 20.97
        }

    ]
}