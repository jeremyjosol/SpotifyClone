using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicOrganizer.Models;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace SpotifyClone.Tests
{
  [TestClass]
  public class AlbumTests : IDisposable
  {
    public void Dispose()
    {
      Album.ClearAll();
    }
    [TestMethod]
    public void AlbumConstructor_CreatesInstanceOfAlbum_Album()
    {
      Album newAlbum = new Album("Test album");
      Assert.AreEqual(typeof(Album), newAlbum.GetType());
    }
    [TestMethod]
    public void AlbumName_ReturnsAlbumName_String()
    {
      string albumName = "Black Metal";
      Album newAlbum = new Album(albumName);
      string result = newAlbum.Name;
      Assert.AreEqual(albumName, result);
    }
    [TestMethod]
    public void AlbumId_ReturnsAlbumId_Int()
    {
      string albumName = "Black Metal";
      Album newAlbum = new Album(albumName);
      int result = newAlbum.Id;
      Assert.AreEqual(1, result);
    }
    [TestMethod]
    public void GetAll_ReturnsAllAlbumObjects_AlbumList()
    {
      string albumName01 = "Black Metal";
      string albumName02 = "Black Metal 2";
      Album newAlbum1 = new Album(albumName01);
      Album newAlbum2 = new Album(albumName02);
      List<Album> newList = new List<Album> { newAlbum1, newAlbum2};
      List<Album> result = Album.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }
    [TestMethod]
    public void Find_ReturnsCorrectAlbum_Album()
    {
      string albumName01 = "Black Metal";
      string albumName02 = "Black Metal 2";
      Album newAlbum1 = new Album(albumName01);
      Album newAlbum2 = new Album(albumName02);
      Album result = Album.Find(1);
      Album result2 = Album.Find(2);
      Assert.AreEqual(newAlbum1, result);
      Assert.AreEqual(newAlbum2, result2);
    }
    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      string songTitle = "Forever";
      Song newSong = new Song(songTitle);
      List<Song> newList = new List<Song> { newSong };
      string albumName = "Black Metal";
      Album newAlbum = new Album(albumName);
      newAlbum.AddSong(newSong);
      List<Song> result = newAlbum.Songs;
      CollectionAssert.AreEqual(newList, result);
    }
  }
}