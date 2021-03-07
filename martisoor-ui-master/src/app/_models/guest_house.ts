export interface guestHouseDetail {

    id: string;
    guest_name: string;
    description: string;
    stars: string;
    image_url: string;
    address: AddressGuest;
    rooms: RoomGuest;
    files: FileGuest[];
    amenities: AmenityGuest;

    ratings: RatingGuest[];
    reviews: ReviewGuest[];

    house_rules: GuestRule[];
    average_review: number;
    number_of_review_count: number;
    price: number;
}

// public class _Id
// {
//     oid: string;
// }

 export interface GuestRule {
    id: number;
    rule_name: string;
    allow: boolean;



}

export interface ReviewGuest {
    id: number;
    name: string;
    email: string;

    review: string;
    guest_id: string;

}

    export interface RatingGuest {
    id: number;
    rate: number;
    guest_id: string;
}

 export interface AmenityGuest {
    id: number;
    wifi: boolean;
    fitness_center: boolean;
    cafeteria: boolean;
    restaurant: boolean;
    bathrobes: boolean;
    dry_cleaning: boolean;
    high_chair: boolean;
    slipper: boolean;
    wakeup_call: boolean;
    telephone: boolean;
    air_conditioning: boolean;
    parking: boolean;
    guest_id: string;
}

   export interface FileGuest {
    id: number;

    file_url: string;
    guest_id: string;
}

export interface AddressGuest {
    id: number;
    longitude: number;
    latitude: number;
    area: string;
    city: string;
    guest_id: string;
}

export interface Address1 {
    _id: any;
    longitude: number;
    latitude: number;
    area: string;
    city: string;
    hotel_id: any;
}

export interface RoomGuest {
           id: number;
    room_type: string;

    bath_Rooms: number;

    room_beds: number;


    guest_id: string;
}
