export class Category {
  id: number;
  name: string;
  constructor(res: Category) {
    this.id = res.id;
    this.name = res.name;
  }
}
