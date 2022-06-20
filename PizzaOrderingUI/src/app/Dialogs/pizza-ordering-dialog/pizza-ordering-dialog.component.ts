import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from 'src/app/models/dialog.model';

@Component({
  selector: 'app-pizza-ordering-dialog',
  templateUrl: './pizza-ordering-dialog.component.html',
  styleUrls: ['./pizza-ordering-dialog.component.scss']
})
export class PizzaOrderingDialogComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<PizzaOrderingDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: DialogData,) { }

  ngOnInit(): void {
  }

  onCancelClick(): void {
    this.dialogRef.close(0);
  }

}


