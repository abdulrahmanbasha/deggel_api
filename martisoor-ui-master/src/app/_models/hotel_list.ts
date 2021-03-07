export interface HotelList { 
    id: string;
    hotel_name: string;
    description: string;
    stars: number;
    address: Address;
    image_url: string;
    average_review: number,
    number_of_review_count: number,
    lowest_room_price: number,
}


export interface Address {
    id: number;
    longitude: number;
    latitude: number;
    area: string;
    city: string;
}