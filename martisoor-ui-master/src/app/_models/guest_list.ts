export interface guestHouseList {

  id: string;
  guest_name: string;
  description: string;
  stars: string;
  image_url: string;
  address: AddressGuest;
  average_review: number;
  number_of_review_count: number;
  price: number;
}

export interface AddressGuest {
  id: number;
  longitude: number;
  latitude: number;
  area: string;
  city: string;
  guest_id: string;
}
