﻿namespace MediaLibrary.Classes;

/// <summary>
/// Жанр музыки
/// </summary>
public class Genre
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// Название жанра
    /// </summary>
    public required string Name { get; set; }
}