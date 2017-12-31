import { Component, Inject } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})

export class FetchDataComponent {
	public providers: Provider[];
	private http: Http;
	private baseUrl: string;
	public providerStr: string;
	public bufProvider: Provider = new Provider("", "");
	public formMode: string = "";

	constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
		this.http = http;
		this.baseUrl = baseUrl;
		http.get(baseUrl + 'api/Providers/Read').subscribe(result => {
			this.providers = result.json() as Provider[];
        }, error => console.error(error));
	}

	addProvider(): void {
		this.http.post(this.baseUrl + 'api/Providers/Add', this.bufProvider, undefined)
			.subscribe(result => {
				this.providers = result.json() as Provider[];
				this.bufProvider = new Provider("", "");
			}, error => console.error(error));
	}

	updateProvider(): void {
		this.http.put(this.baseUrl + 'api/Providers/Update', this.bufProvider, undefined)
			.subscribe(result => {
				this.providers = result.json() as Provider[];
				this.bufProvider = new Provider("", "");
			}, error => console.error(error));
	}

	removeProvider(provider: Provider): void {
		this.http.delete(this.baseUrl + 'api/Providers/Delete', new RequestOptions({
			body: provider
		})).subscribe(result => {
			this.providers = result.json() as Provider[];
		}, error => console.error(error));
	}
}

export class Provider {
	id: string;
	provider: string;
	constructor(public ID: string, public Provider: string) {
		this.id = ID;
		this.provider = Provider;
	}
}
