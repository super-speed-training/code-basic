import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  public model: any = [];
  constructor(public navCtrl: NavController, private http: HttpClient) {
  }

  ionViewDidEnter(){
    this.http.get("https://localhost:5001/api/todo").subscribe(
      (success)=>{
        this.model = success;
        console.log(JSON.stringify(success));
      }
    )
  }

  selectitem(id:string){
    this.http.get("https://localhost:5001/api/todo/" + id).subscribe(
      (success)=>{
        alert(JSON.stringify(success));
      }
    )
  }

  additem(){
    this.navCtrl.push("AdditemPage");
  }
}
