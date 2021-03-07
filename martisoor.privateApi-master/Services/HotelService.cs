using System.Collections.Generic;
using AutoMapper;
using bknsystem.privateApi.Dtos;
using bknsystem.privateApi.Interfaces;
using bknsystem.privateApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace bknsystem.privateApi.Services
{
    public class HotelService
    {
        private IMapper _mapper;
        private readonly IMongoCollection<hotel> _hotels;

        public HotelService(IHotelDatabaseSettings settings)
        {

            // var client = new MongoClient("mongodb://mongo_user:db27ZKtgAYeTb4W@cluster0-shard-00-00.sjq6j.mongodb.net:27017,cluster0-shard-00-01.sjq6j.mongodb.net:27017,cluster0-shard-00-02.sjq6j.mongodb.net:27017/bknsystem_db?ssl=true&replicaSet=atlas-nk6365-shard-0&authSource=admin&retryWrites=true&w=majority");
            // var database = client.GetDatabase("bknsystem_db");


            // var client = new MongoClient(settings.ConnectionString);
            // var database = client.GetDatabase(settings.DatabaseName);

            // _hotels = database.GetCollection<hotel>(settings.HotelsCollectionName);

            // _mapper = mapper;
        }





    }
}