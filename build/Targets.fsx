// load dependencies from source folder to allow bootstrapping
#r "/bin/Plainion.CI/FAKE/FakeLib.dll"
#load "/bin/Plainion.CI/bits/PlainionCI.fsx"

open Fake
open PlainionCI

Target "CreatePackage" (fun _ ->
    !! ( outputPath </> "*.*Tests.*" )
    ++ ( outputPath </> "*nunit*" )
    ++ ( outputPath </> "TestResult.xml" )
    ++ ( outputPath </> "**/*.pdb" )
    |> DeleteFiles

    PZip.PackRelease()

    [
        ( projectName + ".*", Some "lib/NET45", None)
    ]
    |> PNuGet.Pack (projectRoot </> "build" </> projectName + ".nuspec") (projectRoot </> "pkg")
)

Target "Deploy" (fun _ ->
    let releaseDir = @"\bin\Plainion.Starter"

    CleanDir releaseDir

    let zip = PZip.GetReleaseFile()
    Unzip releaseDir zip
)

Target "Publish" (fun _ ->
    let zip = PZip.GetReleaseFile()
    PGitHub.Release [ zip ]

    PNuGet.PublishPackage projectName (projectRoot </> "pkg")
)

RunTarget()
