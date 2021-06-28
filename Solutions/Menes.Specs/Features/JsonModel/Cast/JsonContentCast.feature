Feature: JsonContentCast
	Validate the Json cast operators

Scenario: Cast to JsonAny for json element backed value as an content
	Given the JsonElement backed JsonContent "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the JsonContent to JsonAny
	Then the result should equal the JsonAny 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to JsonAny for dotnet backed value as an content
	Given the dotnet backed JsonContent eyAiaGVsbG8iOiAid29ybGQiIH0=
	When I cast the JsonContent to JsonAny
	Then the result should equal the JsonAny 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast from JsonAny for json element backed value as an content
	Given the JsonAny for "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the JsonAny to JsonContent
	Then the result should equal the JsonContent 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to JsonString for json element backed value as an content
	Given the JsonElement backed JsonContent "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the JsonContent to JsonString
	Then the result should equal the JsonString 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to JsonString for dotnet backed value as an content
	Given the dotnet backed JsonContent eyAiaGVsbG8iOiAid29ybGQiIH0=
	When I cast the JsonContent to JsonString
	Then the result should equal the JsonString 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast from JsonString for json element backed value as an content
	Given the JsonString for "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the JsonString to JsonContent
	Then the result should equal the JsonContent 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to ReadOnlySpan<byte> for json element backed value as an content
	Given the JsonElement backed JsonContent "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the JsonContent to ReadOnlySpan<byte>
	Then the result should equal the ReadOnlySpan<byte> 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to ReadOnlySpan<byte> for dotnet backed value as an content
	Given the dotnet backed JsonContent eyAiaGVsbG8iOiAid29ybGQiIH0=
	When I cast the JsonContent to ReadOnlySpan<byte>
	Then the result should equal the ReadOnlySpan<byte> 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast from ReadOnlySpan<byte> for json element backed value as an content
	Given the ReadOnlyMemory<byte> for "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the ReadOnlySpan<byte> to JsonContent
	Then the result should equal the JsonContent 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to ReadOnlySpan<char> for json element backed value as an content
	Given the JsonElement backed JsonContent "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the JsonContent to ReadOnlySpan<char>
	Then the result should equal the ReadOnlySpan<char> 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to ReadOnlySpan<char> for dotnet backed value as an content
	Given the dotnet backed JsonContent eyAiaGVsbG8iOiAid29ybGQiIH0=
	When I cast the JsonContent to ReadOnlySpan<char>
	Then the result should equal the ReadOnlySpan<char> 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast from ReadOnlySpan<char> for json element backed value as an content
	Given the ReadOnlyMemory<char> for "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the ReadOnlySpan<char> to JsonContent
	Then the result should equal the JsonContent 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to string for json element backed value as an content
	Given the JsonElement backed JsonContent "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the JsonContent to string
	Then the result should equal the string 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast to string for dotnet backed value as an content
	Given the dotnet backed JsonContent eyAiaGVsbG8iOiAid29ybGQiIH0=
	When I cast the JsonContent to string
	Then the result should equal the string 'eyAiaGVsbG8iOiAid29ybGQiIH0='

Scenario: Cast from string for json element backed value as an content
	Given the string for "eyAiaGVsbG8iOiAid29ybGQiIH0="
	When I cast the string to JsonContent
	Then the result should equal the JsonContent 'eyAiaGVsbG8iOiAid29ybGQiIH0='

