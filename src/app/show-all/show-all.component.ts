import { Component, OnInit } from '@angular/core';
import { BackendService, ConnectionModel } from '../backend.service';

@Component({
	selector: 'app-show-all',
	templateUrl: './show-all.component.html',
	styleUrls: ['./show-all.component.scss']
})
export class ShowAllComponent implements OnInit
{
	public connections: ConnectionModel[] = [];

	constructor(private backend: BackendService) { }

	ngOnInit(): void
	{
		this.loadConnections();

		setInterval(()=>this.loadConnections(), 10000);
	}

	private loadConnections()
	{
		this.backend.getAllConnections().subscribe({
			next: (connections: ConnectionModel[]) =>
			{
				this.connections = connections;
			},
			error: (error: any) => console.error(error)
		});
	}
}
