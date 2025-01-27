import { Component, OnInit } from '@angular/core';
import { ServiciosContablesService } from '../servicios-contables.service';  // Importa el servicio

@Component({
  selector: 'app-tabla-registros',
  templateUrl: './tabla-registros.component.html',
  styleUrls: ['./tabla-registros.component.css']
})
export class TablaRegistrosComponent implements OnInit {
  registros: any[] = [];  // Propiedad para almacenar los registros

  constructor(private serviciosContablesService: ServiciosContablesService) {}

  ngOnInit(): void {
    this.loadRegistros();  // Cargar los registros cuando el componente se inicializa
  }

  loadRegistros(): void {
    this.serviciosContablesService.getRegistrosContables().subscribe(
      (data) => {
        this.registros = data;  // Asignamos los datos obtenidos al array 'registros'
      },
      (error) => {
        console.error('Error al obtener los registros', error);  // Manejo de errores
      }
    );
  }

  refreshData(): void {
    this.loadRegistros();  // Método para refrescar los datos al hacer clic en el botón
  }
}
