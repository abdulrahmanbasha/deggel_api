using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using bknsystem.privateApi.Dtos;
using bknsystem.privateApi.Helpers;
using bknsystem.privateApi.Interfaces;
using bknsystem.privateApi.Models;
using martisoor.privateApi_master.Dtos;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace martisoor.privateApi_master.Repositories
{
    public class GuestRepository : IGuestRepository
    {
           private IMapper _mapper;
        private readonly IMongoCollection<hotel> _hotels;
        private readonly Datalayer _db;

        public GuestRepository(IHotelDatabaseSettings settings, Datalayer db)
        {
            _db = db;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _hotels = database.GetCollection<hotel>(settings.HotelsCollectionName);

            // _mapper = mapper;
        }
        public PagedList<GuestHouseListSummary_Dto> GetGuestHouseListSummaries(RequestParams requestParams = default)
        {
            var guesthouse_summary = _db.guest_house.AsNoTracking().Include(a => a.address).AsQueryable();
            foreach (var filter in requestParams.GetFilters())
            {
                if (filter.Field == "city")
                {
                    guesthouse_summary = guesthouse_summary.Where(h => h.address.city == filter.Value.ToString());
                }

                if (filter.Field == "hotel_name" && filter.Value.ToString()!="undefined")
                {
                    guesthouse_summary = guesthouse_summary.Where(h => h.guest_name.Contains(filter.Value.ToString()));
                }

                if (filter.Field == "rooms")
                {
                    guesthouse_summary = guesthouse_summary.Where(h => h.rooms.room_beds.ToString().Contains(filter.Value.ToString()));
                }
                if(filter.Field=="stars"){
                    guesthouse_summary=guesthouse_summary.Where(h=>h.stars.ToString().Contains(filter.Value.ToString()));
                }
            }

            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<guestHouse, GuestHouseListSummary_Dto>();
              });
            _mapper = config.CreateMapper();
          
            var guesthouse_summary_list = _mapper.Map<List<GuestHouseListSummary_Dto>>(guesthouse_summary.OrderByDescending(m=>m.stars).ToList());

            var hotelLatest = guesthouse_summary_list.AsQueryable();
            
            // // return PagedList<HotelListSummary_Dto>.CreateAsync(hotelLatest, hotelSearchFilter.PageNumber, hotelSearchFilter.PageSize);


            // // return await PagedList<EmployeePayments>.CreateAsync(hotel, hotelSearchFilter.PageNumber, hotelSearchFilter.PageSize);


            // if (!string.IsNullOrWhiteSpace(hotelSearchFilter.) && hotelSearchFilter.name != "undefined")
            // {
            //     hotels = hotels.Where(c => EF.Functions.Like(c.name, hotelSearchFilter.name + "%%"));
            // }

            // if (hotelSearchFilter.account != 0)
            // {
            //     hotels = hotels.Where(c => c.account == hotelSearchFilter.account);
            // }
            // if (hotelSearchFilter.FromDate != null || hotelSearchFilter.ToDate != null)
            // {
            //     hotels = hotels.Where(c => c.payment_date >= hotelSearchFilter.FromDate && c.payment_date <= hotelSearchFilter.ToDate);
            // }
            // if (!string.IsNullOrEmpty(hotelSearchFilter.OrderBy))
            // {
            //     switch (hotelSearchFilter.OrderBy)
            //     {

            //         default:
            //             hotels = hotels.OrderByDescending(c => c.payment_date);
            //             break;
            //     }
            // }

            return PagedList<GuestHouseListSummary_Dto>.CreateAsync(hotelLatest, 1, 200);
        }



        public guestHouse GetGuestHouseById(string id) =>
               _db.guest_house.Find(id);


        // public List<HotelListSummary_Dto> GetGuestHouseSummaryList()
        // {

        //     var guesthouse_summary = _hotels.Find(hotel => true).ToList();

        //     //var test = _hotels.Aggregate().Unwind("stars").Group(new BsonDocument{{"_id", "$_id"}, {""}})
        //     List<HotelListSummary_Dto> guesthouse_summary_list = new List<HotelListSummary_Dto>();

        //     var config = new MapperConfiguration(cfg =>
        //       {
        //           cfg.CreateMap<hotel, HotelListSummary_Dto>();
        //       });
        //     _mapper = config.CreateMapper();
        //     guesthouse_summary_list = _mapper.Map<List<HotelListSummary_Dto>>(guesthouse_summary);
        //     return guesthouse_summary_list;
        // }


        public guestHouse Create(GuestHouseCreateForm_Dto hotelCreateForm_)
        {
            guestHouse guesthouse_form = new guestHouse();

            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<GuestHouseCreateForm_Dto, guestHouse>();
              });
            _mapper = config.CreateMapper();
            guesthouse_form = _mapper.Map<guestHouse>(hotelCreateForm_);
            // guesthouse_form.address.guest_id=hotelCreateForm_.id;
            // guesthouse_form.amenities.guest_id=hotelCreateForm_.id;
            // guesthouse_form.files
            _db.Add(guesthouse_form);
            _db.SaveChanges();
            return guesthouse_form;
        }



        public string UpdateGuest(string id, guestHouse guestHouseUpdateForm)
        {

            if (id != guestHouseUpdateForm.id)
            {
                return "Not Found";
            }

            _db.Entry(guestHouseUpdateForm).State = EntityState.Modified;

            try
            {
                 _db.SaveChanges();
                return "Successfully Updated Hotel";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }


        public string DeleteGuestHouse(string id)
        {


            var guestHouse =  _db.guest_house.Find(id);
            if (guestHouse == null)
            {
                return "Not Found";
            }

            try
            {
                _db.guest_house.Remove(guestHouse);
                _db.SaveChanges();

                return "Deleted";
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

    }
}