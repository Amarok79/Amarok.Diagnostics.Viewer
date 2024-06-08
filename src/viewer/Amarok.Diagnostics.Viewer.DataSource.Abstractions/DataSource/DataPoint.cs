// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

namespace Amarok.DataSource;


/// <summary>
///     Represents a single data point.
/// </summary>
/// 
/// <param name="Timestamp">
///     The date and time when the data point was captured.
/// </param>
/// <param name="Value">
///     The numeric value of the data point.
/// </param>
public readonly record struct DataPoint(DateTime Timestamp, Double Value);
