export interface WithId {
  id: string | number;
  [key: string]: any;
}

export interface TableColumns<T extends WithId, P extends T> {
  name: keyof P;
  label?: string;
  sortable?: boolean;
  renderItem?: (item: T) => React.ReactNode;
}
