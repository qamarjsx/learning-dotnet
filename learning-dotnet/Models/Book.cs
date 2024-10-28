using System;
using Microsoft.VisualBasic;

namespace learning_dotnet.Models;

public class Book
{
   public int Id { get; set; }
   public required string Title { get; set; }
   public required string Author { get; set; }
   public int PublishYear { get; set; }
}