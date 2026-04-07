export interface Nationality {
  id: number;
  name: string;
  trophies: number;
}

export interface Club {
  id: number;
  name: string;
  foundationDate: string; 
  trophies: number;
}

export interface Player {
  id: number;
  firstName: string;
  lastName: string;
  age: number;
  weight: number;
  price: number;     
  position: string;  
  clubId: number;
  nationalityId: number;
  club?: Club;
  nationality?: Nationality;
}